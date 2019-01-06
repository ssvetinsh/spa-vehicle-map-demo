namespace SpaVehicleMapDemo.BusinessLogic.Constants
{
    public static class ApiUrls
    {
        public static string UserListUrl => "http://mobi.connectedcar360.net/api/?op=list";
        public static string VehicleLocationUrl => "http://mobi.connectedcar360.net/api/?op=getlocations&userid={0}";
    }
}
