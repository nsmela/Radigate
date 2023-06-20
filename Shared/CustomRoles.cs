namespace Radigate.Shared {
    // https://stackoverflow.com/questions/700166/allow-multiple-roles-to-access-controller-action
    public static class CustomRoles {
        public const string Admin = "Admin";
        public const string Viewer = "Viewer";
        public const string AdminOrViewer = Admin + ", " + Viewer;
    }
}
