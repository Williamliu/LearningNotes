import dd, { iSQL, SQL, DefaultHost, dhost } from './modules/ModuleA'; 
//import('./modules/ModuleC').then(m=>{ console.log(`import: ${m.default}`);}).catch(e=>{console.log(e)});  不支持动态加载？

console.log(dd + " : " + dhost);
let c: SQL = new SQL("Radiant.Net", 81);
c.Show();



( function()
{
    const ca:string = "Corona Virus";
    function sh() {
        console.log(`Virus Name : ${ca} + ${dd}`);
    }
    sh();
}
)();

