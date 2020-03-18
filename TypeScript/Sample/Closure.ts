var foo = 123;
if(true) { 
    var foo = 456
}

function test() {
    var foo = 678;
    console.log(`Function Foo = ${foo}`);
}
test();
console.log(`Foo = ${foo}`);


function Person() {
    this.age = 0;
    var name = "William";
    this.Add = function() {
        this.age++;
    }
    this.Show = function() {
        console.log(`Age = ${this.age}`);
    }
}

let p = new Person();
console.log(`Name is ${p.name}`);

p.Add();
p.Show();
console.log(`------------------------------------------`);
setTimeout(p.Add, 1000);
setTimeout(p.Show, 2000);


console.log('---Class  Closure---');
class Radiant {
    public port:number = 0;
    constructor(){}
    public Add() {
        this.port++;
    }
    public Show() {
        console.log(`Port = ${this.port}`);
    }
}

let rd:Radiant = new Radiant();
//var port = 100;
//setTimeout(rd.Add,1000);
//setTimeout(rd.Show,2000);

setTimeout( ()=>{rd.Add() },1000);
setTimeout( ()=>{rd.Add() },1200);
setTimeout( ()=>{rd.Show() },2200);



console.log('---Class1  Closure---');
class Radiant1 {
    public port:number = 0;
    constructor(){}
    public Add:()=>void = ()=> {
        this.port++;
    }
    public Show:()=>string = ():string=>{
        console.log(`Port = ${this.port}`);
        return 'port';
    }
    public Log = (a:string, b:number):string=>{
        let msg = `string a=${a}  number b=${b}`;
        console.log(msg);
        return msg;
    }
}

let rd1:Radiant1 = new Radiant1();
setTimeout(rd1.Add,1000);
setTimeout(rd1.Add,1000);
setTimeout(rd1.Show,2000);
rd1.Log("GoCO", 2020);



