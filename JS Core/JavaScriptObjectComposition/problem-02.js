function solve(worker) {
    if(worker.handsShaking === true) {
        worker.bloodAlcoholLevel += (worker.weight * 0.1) * worker.experience;
        worker.handsShaking = false;
    }

    return worker;
}