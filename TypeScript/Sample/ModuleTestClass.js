"use strict";
exports.__esModule = true;
var ClassModule_1 = require("./modules/ClassModule");
console.log("Default BB=" + ClassModule_1["default"]);
var Order = new ClassModule_1.ORDER("Radiant", 1050);
Order.Place("Banana", 19988);
Order.Place1({ Name: "Plum", Qty: 10 });
Order.Show();
