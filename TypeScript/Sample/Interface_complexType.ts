interface iTech {
    new (n1:number, n2:number):void;
    show():string;
    num1:number;
    num2:number;
}
function createTech(n1:number, n2:number):iTech {
    let techClass = function(a:number, b:number):void {
        this.num1 = n1+1000;
        this.num2 = n2+1000;
        console.log(`tech Func (${a}, ${b})`);
    }

    let techFunc = new techClass(n1,n2);

    techFunc.show = function() {
        let msg = `Show Function total:${this.num1 + this.num2}`;
        console.log(msg);
        return msg;
    }
    return techFunc;
}

let f1: iTech = createTech(100,200);
console.log(f1.num1 + '   ' + f1.num2);
f1.show();