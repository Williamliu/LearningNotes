"use strict";
exports.__esModule = true;
var Item = /** @class */ (function () {
    function Item() {
    }
    return Item;
}());
exports.ITEM = Item;
var Order = /** @class */ (function () {
    function Order(Name, Qty) {
        this.Name = Name;
        this.Qty = Qty;
        this.Orders = [];
    }
    Order.prototype.Show = function () {
        var msg = "Order: Name=" + this.Name + " Quantity=" + this.Qty;
        console.log(msg);
        console.log(this.Orders);
        return msg;
    };
    Order.prototype.Place = function (s, q) {
        this.Orders.push({ Name: s, Qty: q });
    };
    Order.prototype.Place1 = function (o) {
        this.Orders.push(o);
    };
    return Order;
}());
exports.ORDER = Order;
exports["default"] = 200;
