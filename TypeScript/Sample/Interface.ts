interface iConstruct {
    new (s:string, n:number);
}
interface iEvent {
    callEvent():void;
}

function createInstance(ctr:iConstruct, s1:string, n1:number):iEvent {
    return new ctr(s1, n1);
}

class HolidayEvent implements iEvent {
    public name:string;
    public orderNumber:number;
    constructor(a:string, b:number) {
        this.name = a;
        this.orderNumber = b;
    }

    public callEvent() {
        console.log(`Holiday Event: ${this.name}  Day: ${this.orderNumber}`);
    }

    public Add(s:string, n:number) {
        this.name += " " + s;
        this.orderNumber+=n;
        console.log(`Add: ${this.name} Day: ${this.orderNumber}`);

    }

    public GetEvent():iEvent {
        console.log("Holiday Event Get iEvent");
        return <iEvent>this;
    }
}

class IncidentEvent implements iEvent {
    public eventName:string;
    public severity:number;
    constructor(p:string, q:number) {
        this.eventName = p;
        this.severity = q;
    }
    public callEvent() {
        console.log(`Incident Event: ${this.eventName}  severity: ${this.severity}`);
    }
    
    public notify(email:string, times:number) {
        this.eventName += " !!! " + email;
        this.severity += times;
        console.log(`Notify: ${this.eventName} Severity: ${this.severity}`);
    }

    public GetEvent():iEvent {
        console.log("Incident Event Get iEvent");
        return <iEvent>this;
    }
}

let holi = createInstance(HolidayEvent, "Family Day", 17);
holi.callEvent();

let ins = createInstance(IncidentEvent, "Corona Virus", 999);
ins.callEvent();

let hObj:HolidayEvent = new HolidayEvent("Valentine's Day", 14);
hObj.Add('Easter Day', 12);
let hCall = hObj.GetEvent();
hCall.callEvent();
console.log(hObj);
console.log(holi);

let hCall1:iEvent = <iEvent>hObj;
hCall1.callEvent();

let hObj1:HolidayEvent = <HolidayEvent>hCall1;
hObj1.Add("Test", 20);
hObj1.callEvent();
