using Project.Objects;
using Project.UILayer;

namespace Project.Views
{
    public class AdminDelete
    {
        public static void CancelEvent(AdminObjects admin)
        {
            var events = admin.eventContoller.GetAll();
            EventUI.ShowEvents(events);
            EventUI.CancelEvent(admin.eventContoller);
            AdminUI.AdminPage(admin);
        }
    }
}
