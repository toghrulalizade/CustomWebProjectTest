using Core.Utilities.Helper;
using Core.Utilities.Resource.Enum;
using Core.Utilities.Resource.UsableModels.MailTemplate;
using Core.Utilities.Resource.UsableModels.MailTemplate.Sendgrid;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;

namespace Business.ExternalServices.Mail
{
    public class SendgridService
    {
        public  bool SendRecoveryMail(MailRequest request, RecoverOrConfirmationTemplate template)
        {
            bool result;
            try
            {
                var apiKey = "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";

                var client = new SendGridClient(apiKey);

                var sendGridMessage = new SendGridMessage();

                sendGridMessage.SetFrom(request.FromEmail, $"User : {template.UserFirstName}");
                sendGridMessage.AddTo(request.ToEmail, "Password Recovery");
                sendGridMessage.SetTemplateId("d-0df55fe5878e4979a59c9183ef658847");
                sendGridMessage.SetTemplateData(template);

                var response =  client.SendEmailAsync(sendGridMessage).Result;

                result = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }

            return result;
        }

        public bool SendConfirmationMail(MailRequest request, RecoverOrConfirmationTemplate template)
        {
            bool result;
            try
            {
                var apiKey = "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";

                var client = new SendGridClient(apiKey);

                var sendGridMessage = new SendGridMessage();

                sendGridMessage.SetFrom("togrul325@touchacademy.az", $"User : {template.UserFirstName}");
                sendGridMessage.AddTo(request.ToEmail, "Account Confirmation");
                sendGridMessage.SetTemplateId("d-ce1038a0cd6347f5ad29acf13bdcbef3");
                sendGridMessage.SetTemplateData(template);

                var response = client.SendEmailAsync(sendGridMessage).Result;

                result = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }

            return result;
        }
    }
}
