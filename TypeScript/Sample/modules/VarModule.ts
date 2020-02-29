var PI:number = 3.141592614;
export default PI;
//export default 33;
//export {PI as default};
export var Street:string = `Vancouver Street ${PI}`;

let Good:number = 99;
export {Good as GD, PI};

export namespace LWH {
    export var Unit:number = 6540;
    // export default 5577;  only allow in root 
}