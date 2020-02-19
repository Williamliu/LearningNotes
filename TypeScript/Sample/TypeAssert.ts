function isNumber(n: string|number): n is number {
    return typeof(n)=="number"?true:false;
}

function isString(n: string|number): n is string {
    return typeof(n)=="string"?true:false;
}

let n1:string|number=3000;
let res = n1 + 200;
console.log(res);


if( isString(n1) ) {
    let res:number = Number(n1) + 20000;
    // <number>n1  出错， 不能类型强制转化
    console.log(res);
}
else {
    let m = n1 / 60;
    console.log(m);
}