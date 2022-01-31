using KaspiTestApp.Controllers;

namespace KaspiTestApp
{
    public class Checkers
    {
        private static string minAmountErrorRu = "Минимальная сумма для пополнения - 1 тенге";
        private static string minAmountErrorKz = "Толықтыру үшін ең аз сома – 1 теңге";
        private static string maxAmountErrorRu = "Максимальная сумма для пополнения - 500000 тенге";
        private static string maxAmountErrorKz = "Толықтыру үшін максималды сома – 500 000 теңге";
        public static string getProvider(string acc) 
        {
            string prefix = acc.Substring(0,3);
            int prefixInt = Convert.ToInt32(prefix);

            switch (prefixInt) 
            {
            case 701:
                    return "Activ";
            case 777:
            case 705:
                    return "Beeline";
            case 707:
            case 747:
                    return "Tele2";
            case 700:
            case 708:
                    return "Altel";

            default:
                    return "Unknown operator";
            }
        }
        public static string getMessageByProvider(string provider) 
        {
            string message = string.Empty;
            switch (provider)
            {
                case "Activ":
                    message = "Платеж по номеру Kcell успешно проведен";
                    break;
                case "Beeline":
                    message = "Платеж по номеру Beeline успешно проведен";
                    break;
                case "Tele2":
                    message = "Платеж по номеру Tele2 успешно проведен";
                    break;
                case "Altel":
                    message = "Платеж по номеру Altel успешно проведен";
                    break;

                default:
                    message = "Неизвестный поставщик";
                    break;
            }
            return message;
        }

        public static int makePaymentCheck(Payment payment)
        {
            if (payment.Amount <= 0)
            {
                return 109;
            }
            if (payment.Amount > 500000)
            {
                return 110;
            }
            return 0;
        }
        public static string MinAmountErrorRu
        {
            get
            {
                return minAmountErrorRu;
            }
            set
            {
                minAmountErrorRu = value;
            }
        }
        
        public static string MinAmountErrorKZ
        {
            get
            {
                return minAmountErrorKz;
            }
            set
            {
                minAmountErrorKz = value;
            }
        }
        public static string MaxAmountErrorRu
        {
            get
            {
                return maxAmountErrorRu;
            }
            set
            {
                maxAmountErrorRu = value;
            }
        }

        public static string MaxAmountErrorKZ
        {
            get
            {
                return maxAmountErrorKz;
            }
            set
            {
                maxAmountErrorKz = value;
            }
        }
    }
}
