using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resource.UsableModels.MailTemplate
{
    public class MailRequest
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string ContentText { get; set; }
        public bool IsHtmlContent { get; set; }
        public string Subject { get; set; }
    }
}
