let a1:string = "2012-1-1";
let a2:number = 100;
let a3:Array<number> = [1,2];
let a4:Array<string> = ["abc", "cde"];
let a5:boolean = true;
let a6:Date = new Date();
let a7: string|Date = new Date();
let a8: string|Date = "Hello";
let a9: void = null;
let a10: never;
let a11 = {};
console.log(`a1=${typeof(a1)}`);
console.log(`a2=${typeof(a2)}`);
console.log(`a3=${typeof(a3)}`);
console.log(`a4=${typeof(a4)}`);
console.log(`a5=${typeof(a5)}`);
console.log(`a6=${typeof(a6)}`);
console.log(`a7=${typeof(a7)}`);
console.log(`a8=${typeof(a8)}`);
console.log(`a9=${typeof(a9)}`);
console.log(`a10=${typeof(a10)}`);
console.log(`a11=${typeof(a11)}`);

//console.log(`a1 instance of String: ${a1 instanceof String }`);   error
console.log(`a4 instance of Array: ${a4 instanceof Array }`);
console.log(`a4 instance of Object: ${a4 instanceof Object }`);
console.log(`a6 instance of Date: ${a6 instanceof Date }`);
console.log(`a11 instance of Array: ${a11 instanceof Array }`);
console.log(`a11 instance of Object: ${a11 instanceof Object }`);
console.log(`a4 isArray : ${Array.isArray(a4)}`);
console.log(`a1 Date.parse : ${ Date.parse(a1) }`);

class MyClass {
    public Name:string;
    //constructor(public Name:string) {};
    public show() {
        console.log(`Class Show Name = ${this.Name}`);
    }
}

let c1 = new MyClass();
c1.show();

console.log( c1.constructor.toString() );
console.log(`c1 typeof : ${ typeof(c1)}`);
console.log(`c1 instanceof MyClass: ${c1 instanceof MyClass}`);