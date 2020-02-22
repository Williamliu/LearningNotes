class Radiant {
    private _company:string;

    get Company() {
        return this._company === "Radiant"?this._company + " Communication Inc.": this._company + " Limited.";
    }

    set Company(n:string) {
        if(n=="ABC") 
            this._company = n + " Company";
        else
            this._company = n;
    }

    public show() {
        console.log(`Company = ${this.Company}  _company: ${this._company}`);
    }
}

let rd: Radiant = new Radiant();
rd.Company="Hello World";
rd.show();
rd.Company = "Radiant";
rd.show();

