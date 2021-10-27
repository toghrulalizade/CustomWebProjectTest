using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resource.UsableModels.MailTemplate.Sendgrid
{
    public class RecoverOrConfirmationTemplate
    {
        public string RedirectLink { get; set; }
        public string MailSubject {get; set; }
        public string UserFirstName {get; set; }
    }
}
