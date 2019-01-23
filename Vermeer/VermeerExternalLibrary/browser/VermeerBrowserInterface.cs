using IndieGoat.MaterialFramework.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moonbyte.Vermeer.browser
{
    public interface VermeerBrowserInterface
    {
        /* Default / required browser events */
        event EventHandler<DocumentTitleChange> OnTitleChange;
        event EventHandler<DocumentURLChange> OnDocumentURLChange;
        event EventHandler<DocumentIconChange> OnDocumentIconChange;

        /* Default / required Browser Properties */
        Control GetBrowserControl();
        bool IsLoading();
        bool IsBackEnabled();
        bool IsForwardAvailable();
        MaterialTabPage getTabPage();

        /* Initialize */
        void CreateBrowserHandle(string URL, MaterialTabPage tabPage);


        /* Default / required Browser controlls */
        void GoBack();
        void GoForward();
        void Navigate(string URL);
    }

    public class DocumentTitleChange : EventArgs
    { public string DocumentTitle; }
    public class DocumentURLChange : EventArgs
    { public string DocumentURL; }
    public class DocumentIconChange : EventArgs
    { public Image icon; }
}
