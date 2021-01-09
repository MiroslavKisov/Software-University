function solve(numberOfSteps, footPrintLength, speedKmPerHour) {

    let distanceToTravelInMeters = numberOfSteps * footPrintLength;
    let speedMetersPerSecond = (speedKmPerHour * 1000) / 3600;
    let restTime = 60 * Math.trunc(distanceToTravelInMeters / 500);
    let totalSeconds = (distanceToTravelInMeters / speedMetersPerSecond) + restTime;

    let hours = Math.floor(totalSeconds / 3600);
    let minutes = Math.floor(totalSeconds / 60);
    let seconds = Math.ceil(totalSeconds - (hours * 3600) - (minutes * 60));

    let hoursToString = hours.toString();
    let minutesToString = minutes.toString();
    let secondsToString = seconds.toString();

    console.log(`${hoursToString.padStart(2, '0')}:${minutesToString.padStart(2, '0')}:${secondsToString.padStart(2, '0')}`)
}

solve(4000, 0.60, 5);