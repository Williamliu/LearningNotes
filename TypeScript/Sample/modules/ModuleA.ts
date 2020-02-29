import * as MA from './ModuleB';
import def  from './ModuleC';
console.log(`Module A default=${def}`);

//export { default } from './ModuleC';
class SQL implements MA.iSQL {
    public Host:string = MA.DefaultHost;
    public Port:number = 80;
    public Connection:string;
    constructor(h:string, p:number) {
        this.Host = h && h!=""?h:this.Host;
        this.Port = p>0?p:this.Port;
        this.Connection = `host=${this.Host};port=${this.Port}`;
    }

    public Connect(s:string, n:number):string {
        this.Host = s;
        this.Port = n;
        this.Connection = `host=${this.Host};port=${this.Port}`;
        return this.Connection;
    }
    public Show() {
        console.log(this.Connection);
    }
}

export {SQL}
//export {MA} 

export  *  from './ModuleB';
export { default } from './ModuleC';
export {iSQL, DefaultHost as dhost} from './ModuleB';
//不支持这种输出
//export gg from './ModuleC';
//export * as someIdentifier from "someModule";
//export someIdentifier from "someModule";
//export someIdentifier, { namedIdentifier } from "someModule";


