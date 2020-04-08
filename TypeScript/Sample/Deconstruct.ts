let arr:Array<number> = [10,20, 30, 40];
let [x, y, ...other] = arr;
let z1 = [arr, 50, 60];
let z2 = [...arr, 50, 60];
console.log(z1);
console.log(z2);


let a = 100;
let b = 200;
[b, a] = [a, b];
console.log(`a=${a} b=${b}`);

let [a1, a2] = [30, 40];
[a2, a1] = [a1, a2];
console.log(`a1=${a1}  a2=${a2}`);

 
function Show(x, y, ...args) {
    console.log(arguments);
    console.log(x);
    console.log(y);
    console.log(args);
}
Show("William", 500, new Date(), true, "Good", 999, {x:8,y:9});
