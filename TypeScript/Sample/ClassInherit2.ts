class iClass {
    constructor(public Host:string, public Port:number) {
        console.log(`iClass Host: ${Host}  Port: ${Port}`);
    }
    public showme():string {
        let msg = `Host: ${this.Host}  Port: ${this.Port}`;
        console.log(`iClass Message: ${msg}`);
        return msg;
    }

    public AddPort(n:number) {
        this.Port += n;
    }
}

interface iA extends iClass {
    SubPort(n1:number):number;
}
interface iB {
    showAll():string;
}

class MyClass extends iClass implements iB {
    public title:string = "CTO CEO";
    public SubPort(n:number):number {
        this.Port -= n;
        return this.Port;
    }

    public showAll():string {
        let msg:string = `ShowAll host=${this.Host} port=${this.Port} title:${this.title}`;
        console.log(msg);
        return msg;
    }
}

let m:MyClass = new MyClass("Radiant.Net", 1433);
m.AddPort(1000);
m.showme();
m.SubPort(500);
m.showme();

let nc:iA = <iA>m;
console.log("-----iA-----------------------");
nc.showme();

let nb:iB = <iB>m;
console.log("-----iB-----------------------");
nb.showAll();


let tt:MyClass = <MyClass>nb;
console.log("-----MyClass-----------------------");
tt.showme();


console.log("-----YClass------------------------");
class bClass {
    constructor(public Name:string) {
        this.Name += ' bClass!';
        console.log(`bClass Name = ${this.Name}`);
    }
    public getName():string {
        return this.Name;
    }
}

class YClass extends bClass {
    constructor(public Name:string) {
        super(Name);        
        console.log(`YClass Name: ${this.Name}`);
    }


    public show() {
        console.log(`Show this.Name=${this.Name}  super.Name=${super.getName()}`);
    }
}

let y1:YClass = new YClass("Radiant Communications");
y1.show();
