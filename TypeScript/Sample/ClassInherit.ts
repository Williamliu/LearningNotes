interface iA {
    Name:string;
    Total:number;
    Add(n1:number, n2:number):number;
}

interface iB {
    Name: string;
    Square: number;
    Multiply(n1:number):number;
}


interface iC extends iA, iB {
    Squart(n1:number, n2:number):number;
}

abstract class bCal implements iC {
    constructor(public Name:string) {
        console.log(`bCal Name: ${this.Name}`);
    }
    public Show1() {
        console.log(`Result: total: xx Square: xx`);
    }
    abstract Square:number;
    abstract Total:number;
    abstract Squart(n:number, n1:number):number;
    abstract Add(n:number, n1:number):number;
    abstract Multiply(n:number):number;
}

class Cal extends bCal implements iA, iB, iC {
    public Total:number;
    public Square:number;
    private n1:number;
    private n2:number;
    constructor(public Name:string, a:number, b:number) {
        super(Name);
        this.n1 = a;
        this.n2 = b;
    }

    public Add(a, b) {
        this.Total = a+b;
        return a+b;
    }
    public Multiply(a) {
        this.Square = this.Total * a;
        return this.Square;
    }

    public Squart(n:number, m:number) {
        console.log(`Squart: ${n} * ${m} = ${n*m} !!!`);
        return n*m;
    }

    public Show() {
        console.log(`Name: ${this.Name} Result: total: ${this.Total} Square: ${this.Square}`);
    }
}

let cc:Cal = new Cal("Math", 20,25);
cc.Add(2,3);
cc.Multiply(10);
console.log(`Square:  ${cc.Squart(100,100)}`);
cc.Show();
cc.Show1();