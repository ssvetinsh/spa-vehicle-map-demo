angular.module('VehicleApp', [])
    .controller('VehicleCtrl', function ($scope, $http) {
        $scope.title = loadingTitle;
        $scope.loading = false;
        $scope.owners = [];
        $scope.vehicleLocations = [];

        $scope.init = function () {
            loadVehicleList();
        };

        $scope.toggleVehicleList = function (userId) {
            if (userId === selectedUserId) {
                selectedUserId = null;
                selectedVehicleIds = [];
            } else {
                showVehicleLocations(userId);
            }
        };

        $scope.toggleVehicle = function (vehicleId) {
            if (selectedVehicleIds.includes(vehicleId)) {
                selectedVehicleIds.splice(selectedVehicleIds.indexOf(vehicleId), 1);
            } else {
                selectedVehicleIds.push(vehicleId);
            }
        };

        $scope.isUserSelected = function (userId) {
            return userId === selectedUserId;
        };

        $scope.isVehicleSelected = function (vehicleId) {
            return selectedVehicleIds.includes(vehicleId);
        };

        var loadingTitle = "Loading...";
        var selectedUserId = null;
        var selectedVehicleIds = [];
        var maps = {};

        var loadVehicleList = function () {
            startDataLoad();

            $http.get("/vehicle/GetVehicleUserList")
            .then(function (response) {
                $scope.owners = response.data;
                endDataLoad("Vehicle List");
            });
        };

        var showVehicleLocations = function (userId) {
            startDataLoad();

            $http.get("/vehicle/GetUserVehicleLocations", { params: { userId: userId }})
                .then(function (response) {
                    selectedUserId = userId;
                    displayMap(userId, response.data);
                    endDataLoad("Vehicle Map");
                });
        };

        // TODO: move Map logic to separate JS file
        var displayMap = function (userId, vehicleLocations) {
            setTimeout(function () {
                if (maps[userId] === undefined) {
                    maps[userId] = new ol.Map({
                        target: 'vehicleMap' + userId,
                        layers: [
                            new ol.layer.Tile({
                                source: new ol.source.OSM()
                            })
                        ],
                        view: new ol.View({
                            center: [0, 0],
                            zoom: 4
                        })
                    });                   
                }

                if (vehicleLocations && vehicleLocations.length !== 0) {
                    var latSum = 0;
                    var lonSum = 0;

                    vehicleLocations.forEach(function (location) {
                        latSum += location.Latitude;
                        lonSum += location.Longitude;

                        putMapMarker(maps[userId], location, );
                    });

                    centerMap(maps[userId], lonSum / vehicleLocations.length, latSum / vehicleLocations.length);
                }
            }, 100);
        };

        var putMapMarker = function (map, vehicleLocation) {
            var markerStyle = new ol.style.Style({
                strokeWidth : 3,
                fillColor: getRandomColor()
            });
            var marker = new ol.Feature({
                geometry: new ol.geom.Point(
                    ol.proj.fromLonLat([vehicleLocation.Longitude, vehicleLocation.Latitude])
                ),
                style: markerStyle
            });
            var vectorSource = new ol.source.Vector({
                features: [marker]
            });
            var markerVectorLayer = new ol.layer.Vector({
                source: vectorSource
            });
            map.addLayer(markerVectorLayer);
        };

        var centerMap = function (map, lon, lat) {
            var mapView = map.getView();

            mapView.setCenter(ol.proj.transform([lon, lat], 'EPSG:4326', 'EPSG:3857'));
            mapView.setZoom(10);
        };

        // TODO: move to separate Graphic Helper JS file
        var getRandomColor = function () {
            var letters = '0123456789ABCDEF';
            var color = '#';
            for (var i = 0; i < 6; i++) {
                color += letters[Math.floor(Math.random() * 16)];
            }
            return color;
        };

        var startDataLoad = function () {
            $scope.title = loadingTitle;
            $scope.loading = true;
        };

        var endDataLoad = function (pageTitle) {
            $scope.title = pageTitle;
            $scope.loading = false;
        };
    });