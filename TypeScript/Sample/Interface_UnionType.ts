interface iCat {
    speed:number;
    run():string;
}

interface iFish {
    deep:number;
    swim():string;
}

class Cat implements iCat {
    constructor(public speed: number) {}
    public run():string {
        let msg =`Cat run speed=${this.speed}`;
        console.log(msg);
        return msg;
    }
}
class Fish implements iFish {
    constructor(public deep:number){}
    public swim():string {
        let msg = `Fish can swim in deep=${this.deep}`;
        console.log(msg);
        return msg;
    }
}
class Bear {
    constructor(public weight:number) {

    }
    public heavy():string {
        let msg = `Bear heavy=${this.weight} lbs`;
        console.log(msg);
        return msg;
    }
}

class Animal {
    public static getPet(a: iCat|iFish): iCat|iFish {
        console.log(`Animal Cat type=${typeof(<iCat>a)} `);
        console.log(`Animal Fish type=${typeof(<iFish>a)} `);
        
        if( Animal.isCat(a) ) a.run(); else a.swim();

        
        if(  Animal.isFish(a) ) {
            a.swim();
            return a;
        } 
    
        if( Animal.isFish(a)==false) {
            a.run();
            return a;
        }
        
        //return undefined;
    }

    public static isFish(p: iCat|iFish): p is iFish {
        return <iFish>p && (<iFish>p).swim?true:false;
    }
    public static isCat(p: iCat|iFish): p is iCat {
        return <iCat>p && (<iCat>p).run?true:false;
    }

}

console.log(`-----------------------------`);
let a1:Cat = new Cat(500);
console.log( Animal.getPet(a1) );
console.log(`Is Fish: ${ Animal.isFish(a1) }`);


console.log(`-----------------------------`);
let a2=<Fish> {
        deep:400, 
        swim: function() {
                    let msg = `fish object swim in deep=${this.deep}`;
                    console.log(msg);
                    return msg;
                  }
        };
console.log( Animal.getPet(a2) );

console.log(`Is Fish: ${ Animal.isFish(a2) }`);



console.log(`-----------------------------`);
let a3 = null;
console.log( Animal.getPet(a3) );

