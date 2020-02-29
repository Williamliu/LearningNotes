import bb, { ORDER, ITEM } from './modules/ClassModule';

console.log(`Default BB=${bb}`);

let Order: ORDER = new ORDER("Radiant", 1050);
Order.Place("Banana", 19988);
Order.Place1( <ITEM>{Name:"Plum", Qty: 10} );
Order.Show();

