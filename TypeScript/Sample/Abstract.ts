interface iSQL {
    Host:string;
    Port:number;
    connect(a:string):string;
}

abstract class baseClass implements iSQL {
    abstract Port:number;
    constructor(public Name: string, public Host:string) {}
    public abstract connect(s:string):string;

    abstract show():void;
    protected abstract TCL:number;
    protected abstract Display():string;

    protected abstract get Age():number;
    protected abstract set Age(a:number);
}


class MyClass extends baseClass {
    public Port:number = 1433;
    public TCL:number=20;
    constructor(public Host:string) {
        super("SQLSever", Host);
        
    }

    public  connect(s:string):string {
        this.Host = s;
        return `Server=${this.Host};Port=${this.Port};ConnectName=${this.Name}`;
    }

   
    public show():void {
        console.log(`Show: Server=${this.Host};Port=${this.Port};Tcl=${this.Age};ConnectName=${this.Name}`);
    }


    protected Display():string {
        let msg = `Server=${this.Host};Port=${this.Port};ConnectName=${this.Name}`;
        console.log(`Display: ${msg} Age: ${this.Age}`);
        return msg;
    }

    protected get Age():number {
        return 99;
    }
    protected set Age(a:number) {
        this.TCL = a;
    }
    //public Age:number;
}

let m1: MyClass = new MyClass("LocalHost");
m1.TCL = 988;
//m1.Age = 500;
m1.show();


abstract class baseAge {
    public _age:number;

    protected Total:number;
    public abstract get Age():number;
    public abstract set Age(n:number);
    abstract Show():void;
}

interface iAge extends baseAge {
    Company:string;
}

class Age extends baseAge implements iAge {
    public _age:number;
    public Total:number;

    public get Age():number {
        return this._age
    }
    public set Age(n:number) {
        this._age = n+1000;
    }

    public get Company():string {
        return "Radiant - GoCo";
    }
    public set Company(n:string) {

    }

    public Show() {
        let msg = `Show :  Age = ${this.Age}   Total: ${this.Total}`;
        console.log(msg);
    }
}


let g: Age = new Age();
g.Total = 8000;
g.Age = 500;
g.Show();


class baseShip {
    protected vol:number;
    public Company:string;
}

interface iShip extends baseShip {
}

class Ship extends baseShip implements iShip {
    protected vol:number;
    public Company:string;
}