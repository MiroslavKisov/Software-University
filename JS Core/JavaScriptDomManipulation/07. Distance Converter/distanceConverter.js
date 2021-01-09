function attachEventsListeners() {
    const meterToKilometerCoefficient = 1000;
    const centimeterToMeterCoefficient = 100;
    const centimeterToMilimeterCoefficient = 10;
    const milesToMetersCoefficient = 1609.34;
    const yardsToMetersCoefficient = 0.9144;
    const feetToMetersCoefficient = 0.3048;
    const inchesToMetersCoefficient = 0.0254;

    let convertBtn = $('#convert').on('click', convertMetricUnits);

    function convertMetricUnits() {
        let inputDistance = $('#inputDistance').val();
        let outputDistance = $('#outputDistance');
        let inputUnit = $('#inputUnits option:selected').val();
        let outputUnit = $('#outputUnits option:selected').val();

        switch(inputUnit) {
            case 'km':
                switch(outputUnit) {
                    case 'km':
                        outputDistance.val(inputDistance);
                    break;
    
                    case 'm':
                        outputDistance.val(inputDistance * meterToKilometerCoefficient);
                    break;
    
                    case 'cm':
                        outputDistance.val(inputDistance * meterToKilometerCoefficient * centimeterToMeterCoefficient );
                    break;
    
                    case 'mm':
                        outputDistance.val(inputDistance * meterToKilometerCoefficient * centimeterToMeterCoefficient  * centimeterToMilimeterCoefficient);
                    break;
    
                    case 'mi':
                        outputDistance.val(inputDistance / (milesToMetersCoefficient / meterToKilometerCoefficient));
                    break;
    
                    case 'yrd':
                        outputDistance.val(inputDistance / (yardsToMetersCoefficient / meterToKilometerCoefficient));
                    break;
    
                    case 'ft':
                        outputDistance.val(inputDistance / (feetToMetersCoefficient / meterToKilometerCoefficient));
                    break;
    
                    case 'in':
                        outputDistance.val(inputDistance / (inchesToMetersCoefficient / meterToKilometerCoefficient));
                    break;
                }
            break;

            case 'm':
            switch(outputUnit) {
                case 'km':
                    outputDistance.val(inputDistance / meterToKilometerCoefficient);
                break;

                case 'm':
                    outputDistance.val(inputDistance);
                break;

                case 'cm':
                    outputDistance.val(inputDistance * centimeterToMeterCoefficient);
                break;

                case 'mm':
                    outputDistance.val(inputDistance * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient);
                break;

                case 'mi':
                    outputDistance.val(inputDistance / milesToMetersCoefficient);
                break;

                case 'yrd':
                    outputDistance.val(inputDistance / yardsToMetersCoefficient);
                break;

                case 'ft':
                    outputDistance.val(inputDistance / feetToMetersCoefficient);
                break;

                case 'in':
                    outputDistance.val(inputDistance / inchesToMetersCoefficient);
                break;
            }
            break;

            case 'cm':
            switch(outputUnit) {
                case 'km':
                    outputDistance.val(inputDistance / (meterToKilometerCoefficient * centimeterToMeterCoefficient));
                break;

                case 'm':
                    outputDistance.val(inputDistance / centimeterToMeterCoefficient);
                break;

                case 'cm':
                    outputDistance.val(inputDistance);
                break;

                case 'mm':
                    outputDistance.val(inputDistance * centimeterToMilimeterCoefficient);
                break;

                case 'mi':
                    outputDistance.val(inputDistance / (milesToMetersCoefficient * centimeterToMeterCoefficient));
                break;

                case 'yrd':
                    outputDistance.val(inputDistance / (yardsToMetersCoefficient * centimeterToMeterCoefficient));
                break;

                case 'ft':
                    outputDistance.val(inputDistance / (feetToMetersCoefficient * centimeterToMeterCoefficient));
                break;

                case 'in':
                    outputDistance.val(inputDistance / (inchesToMetersCoefficient * centimeterToMeterCoefficient));
                break;
            }
            break;

            case 'mm':
            switch(outputUnit) {
                case 'km':
                    outputDistance.val(inputDistance / (meterToKilometerCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient));
                break;

                case 'm':
                    outputDistance.val(inputDistance  / (centimeterToMeterCoefficient * centimeterToMilimeterCoefficient));
                break;

                case 'cm':
                    outputDistance.val(inputDistance / centimeterToMilimeterCoefficient);
                break;

                case 'mm':
                    outputDistance.val(inputDistance);
                break;

                case 'mi':
                    outputDistance.val(inputDistance / (centimeterToMeterCoefficient * centimeterToMilimeterCoefficient * milesToMetersCoefficient));
                break;

                case 'yrd':
                    outputDistance.val(inputDistance / (yardsToMetersCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient));
                break;

                case 'ft':
                    outputDistance.val(inputDistance / (feetToMetersCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient));
                break;

                case 'in':
                    outputDistance.val(inputDistance / (inchesToMetersCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient));
                break;
            }
            break;

            case 'mi':
            switch(outputUnit) {
                case 'km':
                    outputDistance.val(inputDistance * (milesToMetersCoefficient / meterToKilometerCoefficient));
                break;

                case 'm':
                    outputDistance.val(inputDistance * milesToMetersCoefficient);
                break;

                case 'cm':
                    outputDistance.val(inputDistance * milesToMetersCoefficient * centimeterToMeterCoefficient);
                break;

                case 'mm':
                    outputDistance.val(inputDistance * milesToMetersCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient);
                break;

                case 'mi':
                    outputDistance.val(inputDistance);
                break;

                case 'yrd':
                    outputDistance.val(inputDistance * (milesToMetersCoefficient / yardsToMetersCoefficient));
                break;

                case 'ft':
                    outputDistance.val(inputDistance * (milesToMetersCoefficient / feetToMetersCoefficient));
                break;

                case 'in':
                    outputDistance.val(inputDistance * (milesToMetersCoefficient / inchesToMetersCoefficient));
                break;
            }
            break;

            case 'yrd':
            switch(outputUnit) {
                case 'km':
                    outputDistance.val(inputDistance * (yardsToMetersCoefficient / meterToKilometerCoefficient));
                break;

                case 'm':
                    outputDistance.val(inputDistance * yardsToMetersCoefficient);
                break;

                case 'cm':
                    outputDistance.val(inputDistance * yardsToMetersCoefficient * centimeterToMeterCoefficient);
                break;

                case 'mm':
                    outputDistance.val(inputDistance * yardsToMetersCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient);
                break;

                case 'mi':
                    outputDistance.val(inputDistance / (milesToMetersCoefficient / yardsToMetersCoefficient));
                break;

                case 'yrd':
                    outputDistance.val(inputDistance);
                break;

                case 'ft':
                    outputDistance.val(inputDistance / (feetToMetersCoefficient / yardsToMetersCoefficient));
                break;

                case 'in':
                    outputDistance.val(inputDistance / (inchesToMetersCoefficient / yardsToMetersCoefficient));
                break;
            }
            break;

            case 'ft':
            switch(outputUnit) {
                case 'km':
                    outputDistance.val(inputDistance * (feetToMetersCoefficient / meterToKilometerCoefficient));
                break;

                case 'm':
                    outputDistance.val(inputDistance * feetToMetersCoefficient);
                break;

                case 'cm':
                    outputDistance.val(inputDistance * feetToMetersCoefficient * centimeterToMeterCoefficient);
                break;

                case 'mm':
                    outputDistance.val(inputDistance * feetToMetersCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient);
                break;

                case 'mi':
                    outputDistance.val(inputDistance / (milesToMetersCoefficient / feetToMetersCoefficient));
                break;

                case 'yrd':
                    outputDistance.val(inputDistance / (yardsToMetersCoefficient / feetToMetersCoefficient));
                break;

                case 'ft':
                    outputDistance.val(inputDistance);
                break;

                case 'in':
                    outputDistance.val(inputDistance / (inchesToMetersCoefficient / feetToMetersCoefficient));
                break;
            }
            break;

            case 'in':
            switch(outputUnit) {
                case 'km':
                    outputDistance.val(inputDistance * (inchesToMetersCoefficient / meterToKilometerCoefficient));
                break;

                case 'm':
                    outputDistance.val(inputDistance * inchesToMetersCoefficient);
                break;

                case 'cm':
                    outputDistance.val(inputDistance * inchesToMetersCoefficient * centimeterToMeterCoefficient);
                break;

                case 'mm':
                    outputDistance.val(inputDistance * inchesToMetersCoefficient * centimeterToMeterCoefficient * centimeterToMilimeterCoefficient);
                break;

                case 'mi':
                    outputDistance.val(inputDistance / (milesToMetersCoefficient / inchesToMetersCoefficient));
                break;

                case 'yrd':
                    outputDistance.val(inputDistance / (yardsToMetersCoefficient / inchesToMetersCoefficient));
                break;

                case 'ft':
                    outputDistance.val(inputDistance / (feetToMetersCoefficient / inchesToMetersCoefficient));
                break;

                case 'in':
                    outputDistance.val(inputDistance);
                break;
            }
            break;
        }
    }
}