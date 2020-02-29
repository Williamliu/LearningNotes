class Item {
    public Name: string;
    public Qty: number;
}

interface iClass {
    new (s:string, q:number);
    Orders:Item[];
    PlaceOrder(s:string, q:number):string;
    Show():void;
}

// 带构造函数的接口：如何实现带构造函数的接口
let Order2:iClass = (
    function(p1:string, p2:number) {
            let temp = function(a:string, b:number) {
                this.Orders.push(<Item> {Name:a, Qty: b});
            }
            temp.prototype.Orders = [];
            temp.prototype.PlaceOrder = function(a:string, b:number):string {
                this.Orders.push( <Item>{Name:a, Qty:b} );
                let msg: string = `Place Order: Name=${a} QTY=${b}`;
                return msg;
            }
            temp.prototype.Show = function():void {
                console.log(this.Orders);
            }

            return <iClass>(new temp(p1, p2));
    }
)("Apple", 300);

Order2.Show();




//Native Javascript: 传统JS 定义类： 留意 静态属性和方法，实例属性和方法
let Order1 = (
    function(){
        function Order1(a:string, b:number) {
            this.Name = a;
            this.Qty = b;
            Order.Total += b;
        }
        
        // Instance 
        Order1.prototype = {
            Name:   "",
            Qty:    0,
            Orders: [],
            PlaceOrder: function(n:string, q:number) {
                Order.Total += q;
                this.Orders.push({Name:n, Qty:q});
            },
            Show: function() {
                console.log(this.Orders);
            }
        }

        // Static Property and Method
        Order1.Total = 0;
        Order1.Display = function() {
            console.log(`Order total of QTY: ${Order.Total}`);  
        }
        return Order1;
    }
)();

let g = new Order1("Apple", 200);
g.PlaceOrder("Banana", 133);
g.PlaceOrder("Plum", 255);
g.Show();
Order1.Display();



// 这是 TypeScript 定义类， 更类似 C# 定义类的语法
class Order {
    public static Total:number=0;
    public Orders: Array<Item>= [];
    constructor(public Name:string, public Qty:number) {
        this.Orders.push(<Item>{Name:this.Name, Qty:this.Qty});
        Order.Total +=  Qty;
    }
    
    public PlaceOrder(n:string, q:number) {
        Order.Total +=  q;
        this.Orders.push(<Item>{Name:n, Qty:q});
    }
    public Show() {
        console.log(this.Orders);
    }

    public static Display() {
        console.log(`Order total of QTY: ${Order.Total}`);
    }
}

let d : Order = new Order("Apple", 10);
d.PlaceOrder("Banana", 35);
d.Show();
Order.Display();
