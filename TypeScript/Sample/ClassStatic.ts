class MyClass {
    public Age:number = 0;
    public static Total:number=0;
    constructor(n:number) {
        MyClass.Total +=n;   
    }

    public show() {
        console.log(`Static Total: ${MyClass.Total} Age: ${this.Age}`);
    }

    public Add() {
        this.Age++;
    }
}

let mc: MyClass = new MyClass(200);
mc.show();
let mc1: MyClass = new MyClass(300);
mc.show();
MyClass.Total = 999;
mc.show();
console.log('----------------------------')
setTimeout(mc.Add, 100);
mc.show();
setTimeout(mc.show, 200);
mc.show();
