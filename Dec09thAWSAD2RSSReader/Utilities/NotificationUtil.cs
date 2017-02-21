using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Utilities
{
    public sealed class NotificationUtil
    {
        public static void ToastNotification(string message)
        {
            var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var toeastElement = notificationXml.GetElementsByTagName("text");
            toeastElement[0].AppendChild(notificationXml.CreateTextNode(message));
            var toastNotification = new ToastNotification(notificationXml);
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }

        public static void TileNotification(string message)
        {
            //Update tile
            XmlDocument newSquareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text04);
            XmlNodeList newSquareTileTextAttributes = newSquareTileXml.
            GetElementsByTagName("text");
            newSquareTileTextAttributes[0].AppendChild(
            newSquareTileXml.CreateTextNode(message));
            TileNotification n = new TileNotification(newSquareTileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(n);
        }
        public static void TileNotification(string message, string icon)
        {
            //Update tile
            XmlDocument newSquareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150PeekImageAndText04);
            newSquareTileXml.GetElementsByTagName("text")[0].AppendChild(newSquareTileXml.CreateTextNode(message));
            ((XmlElement)newSquareTileXml.GetElementsByTagName("image")[0]).SetAttribute("src", icon);
            TileNotification n = new TileNotification(newSquareTileXml);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(n);
        }

        public static void BadgeNotification(string message)
        {
            //Update Badge
            XmlDocument myBadgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeGlyph);
            XmlElement badgeElement = (XmlElement)myBadgeXml.SelectSingleNode("/badge");
            badgeElement.SetAttribute("value", message);
            BadgeNotification myBadge = new BadgeNotification(myBadgeXml);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(myBadge);
        }
    }
}
