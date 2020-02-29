interface iItem {
    Name:string;
    Qty:number;
}

class Item implements iItem {
    public Name: string;
    public Qty: number;
}

class Order implements iItem {
    public Orders: Item[] = [];
    constructor(public Name:string, public Qty:number) {}
    public Show():string {
        let msg = `Order: Name=${this.Name} Quantity=${this.Qty}`;
        console.log(msg);
        console.log(this.Orders);
        return msg;
    }

    public Place(s:string, q:number) {
        this.Orders.push( <Item> {Name:s, Qty:q });
    }
    public Place1(o:Item) {
        this.Orders.push(o);
    }
}

export {Order as ORDER, Item as ITEM}
export default 200;