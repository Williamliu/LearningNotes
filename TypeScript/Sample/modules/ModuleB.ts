import def_host from './ModuleC';
import DefaultHost from './ModuleC';

interface iSQL {
    Connection:string;
    Host:string;
    Port:number;
    Connect(h:string, p:number):string;
}
export {iSQL, def_host as DefaultHost}
let num:number = 399;

export { num as default };
