class MyClass {
    public static Total:number=0;
    constructor(n:number) {
        MyClass.Total +=n;   
    }

    public show() {
        console.log(`Static Total: ${MyClass.Total}`);
    }
}

let mc: MyClass = new MyClass(200);
mc.show();
let mc1: MyClass = new MyClass(300);
mc.show();
MyClass.Total = 999;
mc.show();