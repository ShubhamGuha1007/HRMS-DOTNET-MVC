using HRMS.Notification.Enum;
public class CommonNotification
{
     public static string ShowAlert(Alerts alerts, string showmsg)
    {
        string? msg = null;
        switch (alerts)
        {
            case Alerts.Success:
                msg = "<div class='alert alert-success alert-dismissable' id='alert'>" +
                    "<strong> Success!</ strong > " + showmsg + "</a>.</div>";
                break;
            case Alerts.Error:
                msg = "<div class='alert alert-danger alert-dismissible' id='alert'>" +
                    "<strong> Error!</ strong > " + showmsg + "</a>.</div>";
                break;
            case Alerts.Info:
                msg = "<div class='alert alert-info alert-dismissable' id='alert'>" +
                    "<strong> Info!</ strong > " + showmsg + "</a>.</div>";
                break;
            case Alerts.Warning:
                msg = "<div class='alert alert-warning alert-dismissable' id='alert'>" +
                    "<strong> Warning!</strong> " + showmsg + "</a>.</div>";
                break;
        }
        return msg;
    }
}

