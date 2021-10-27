using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resource.UsableModels.Constants
{
    public static class MessageContainer
    {
        public static class SuccessMessage
        {
            public static string ConfirmationSucceed => "Hormetli {0} {1}! Sizin Hesabiniz Tesdiqlenmisdir! Sayta Daxil Olub Istifadeci Adi ve Sifrenizi Yazaraq Oz Istifadeci Panelinize Daxil Ola Bilersiniz.";
            public static string RegistrationCompletedSuccesfully => "Hormetli {0} {1}! Sizin Qeydiyyat Prosesiniz Ugurla Basa Catmisdir! {2} Elektron Poct Unvanina Sifre Tesdiqleme Poctu Gonderildi. Zehmet Olmasa Emailinize Daxil Olub Hesabinizi Tesdiqleyib Aktivlesdirin.";
            public static string RegisterRecoveryPrepareSucceed => "Ugurlu Emeliyyat! Sizin Elektron Poct Unvaniniza Sifre Yenileme Poctu Gonderildi.";
            public static string UserRecoveryProcessSucceed => "Sifreniz Ugurla Deyisdirildi! Artiq Yeni Sifrenizle Hesabiniza Giris Ede bilersiniz.";
            public static string LoginSucceed => "Siz ugurla hesabiniza giris etdiniz! Istifadeci Paneliniz Yuklenir...";
        }

        public static class ErrorMessage
        {
            
            public static string ConfirmationFailed => "Hesabinizin Tesdiqlenme Prosesi Ugursuz Oldu! Zehmet olmasa tekrar cehd edin ve yaxud +994 51 325 23 25 mobil nomresi ile elaqe saxlayin.";
            public static string RegistrationFailed => "Qeydiyyat Prosesi Ugursuz Oldu! Zehmet olmasa tekrar cehd edin ve yaxud +994 51 325 23 25 mobil nomresi ile elaqe saxlayin.";
            public static string UserMustBeConfirmedByEmail => "Sizin Hesabiniz Tesdiqlenmemisdir! Zehmet olmasa Elektron Poctunuza Daxil Olub Hesabinizi Tesdiqledikden Sonra Tekrar Giris Edin.";
            public static string EmailIsNotSent => "Mail Gonderilmesi Prosesi Ugursuz oldu! Zehmet olmasa tekrar cehd edin ve yaxud +994 51 325 23 25 mobil nomresi ile elaqe saxlayin.";
            public static string UserIsNotFound => "Istifadeci tapilmadi! Zehmet olmasa tekrar cehd edin ve yaxud +994 51 325 23 25 mobil nomresi ile elaqe saxlayin.";
            public static string UserRecoveryProcessFailed => "Sifre Yenileme Prosesi Ugursuz Oldu! Zehmet olmasa tekrar cehd edin ve yaxud +994 51 325 23 25 mobil nomresi ile elaqe saxlayin.";
            public static string LoginFailed => "Istifadeci Adi ve ya Sifre sehvdir. Zehmet olmasa dogru istifadeci adi ve dogru sifre daxil edin";
        }

        public static class InfoMessage
        {
            public static string RegistrationInformation => "";
        }
    }
}
