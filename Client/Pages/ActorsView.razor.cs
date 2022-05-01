namespace ActorsClient.Client.Pages
{
    public partial class ActorsView
    {
        private bool WeatherActorStatus { get; set; } = true;
        private bool IsSunny { get; set; } = true;

        private bool TemperatureActorStatus { get; set; } = true;
        private int TemperaturValue { get; set; } = 20;
        private int TemperaturChangeInput { get; set; }

        private bool AirConditionActorStatus { get; set; } = true;
        private bool AirConditionPowered { get; set; } = true;
        private bool IsActive { get; set; } = false;

        private bool BlindsActorStatus { get; set; } = true;
        private bool BlindsOpened { get; set; } = false;

        private bool MediaStationActorStatus { get; set; } = true;
        private bool MediaStationPowered { get; set; } = false;
        private bool MoviePlaying { get; set; } = false;

        private bool FridgeActorStatus { get; set; } = true;
        private List<string> FridgeContents { get; set; } = new();
        private List<string> FridgeHistory { get; set; } = new();
        private string ProductNameToConsume { get; set; }
        private string ProductNameToOrder { get; set; }


        private List<string> Messages { get; set; } = new();

        private void SetWeather()
        {
            IsSunny = !IsSunny;
            if (IsSunny)
            {
                Messages.Add("Wetter ist sonnig.");
            }
            else
            {
                Messages.Add("Wetter ist nicht mehr sonnig!");
            }
            SetBlinds();
        }

        private void SetTemperature()
        {
            TemperaturValue = TemperaturChangeInput;
            Messages.Add("Temperatur ist " + TemperaturValue.ToString() + "°");
            SetAirCondition();
        }

        private void TurnOnAirCondition()
        {
            AirConditionPowered = true;
            Messages.Add("Klimaanlage eingeschalten");
            SetAirCondition();
        }

        private void TurnOffAirCondition()
        {
            AirConditionPowered = false;
            IsActive = false;
            Messages.Add("Klimaanlage ausgeschalten");
        }

        private void TurnOnMediaStation()
        {
            MediaStationPowered = true;
            Messages.Add("Media Station eingeschalten");
        }

        private void TurnOffMediaStation()
        {
            if (MoviePlaying)
            {
                Messages.Add("Film wurde gestoppt");
            }
            MoviePlaying = false;
            MediaStationPowered = false;
            Messages.Add("Media Station ausgeschalten");
        }

        private void StartMovie()
        {
            if (MoviePlaying)
            {
                Messages.Add("Es läuft bereits ein Film!");
            }
            else
            {
                MoviePlaying = true;
                Messages.Add("Film gestartet");
            }
            SetBlinds();
        }

        private void SetAirCondition()
        {
            if (AirConditionPowered)
            {
                if (TemperaturValue > 20)
                {
                    if (!IsActive)
                    {
                        Messages.Add("Klimaanlage startet kühlen");
                    }
                    IsActive = true;
                }
                else
                {
                    if (IsActive)
                    {
                        Messages.Add("Klimaanlage geht in Standby");
                    }
                    IsActive = false;
                }
            }
        }

        private void SetBlinds()
        {
            if (MoviePlaying)
            {
                if (BlindsOpened)
                {
                    Messages.Add("Blinds werden geschlossen");
                }
                BlindsOpened = false;
            }
            else if (IsSunny)
            {
                if (BlindsOpened)
                {
                    Messages.Add("Blinds werden geschlossen");
                }
                BlindsOpened = false;
            }
            else
            {
                if (!BlindsOpened)
                {
                    Messages.Add("Blinds werden geöffnet");
                }
                BlindsOpened = true;
            }
        }

        private void FridgeConsum()
        {
            if (FridgeContents.Contains(ProductNameToConsume))
            {
                FridgeContents.Remove(ProductNameToConsume);
                Messages.Add("'" + ProductNameToConsume + "' wurde konsumiert");
            }
            else
            {
                Messages.Add("Info: '" + ProductNameToConsume + "' sind aus!");
            }
            ProductNameToConsume = String.Empty;
        }

        private void FridgeOrder()
        {
            string order = "Kühlschrank bestellt '" + ProductNameToOrder + "' am " + DateTime.Now;
            FridgeContents.Add(ProductNameToOrder);
            FridgeHistory.Add(order);
            Messages.Add(order);
            ProductNameToOrder = String.Empty;
        }

        private void ShowFridgeContent()
        {
            Messages.Add("Kühlschrank haltet:");
            foreach (var product in FridgeContents)
            {
                Messages.Add(product);
            }
        }

        private void ShowFridgeHistory()
        {
            Messages.Add("Kühlschrank History:");
            foreach (var entry in FridgeHistory)
            {
                Messages.Add(entry);
            }
        }

    }
}
