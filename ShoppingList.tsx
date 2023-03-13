import { useState, useEffect } from "react";
import { 
    collection, 
    getDocs,
    getDoc,
    addDoc, 
    deleteDoc, 
    doc
  } from "firebase/firestore/lite";
import {db} from "../firebase";
import AddForm from "./AddForm";
import { Item, NewItem } from "../models/models";

interface props {
uid: string | undefined;
email: string | undefined; 
}

const ShoppingList: React.FC<props> = ({uid, email}) => {
  ///For new items
  const [itemTitle, setItemTitle] = useState<string>("");
  const [itemStore, setStore] = useState<string>("");
  const [itemPrice, setPrice] = useState<number>(0);
  const [itemBrand, setBrand] = useState<string>("");

  //For regular use
  const [items, setItems] = useState<Item[]>([]); 
  const [loading, setLoading] = useState(true);
    useEffect(() => {
      const fetchData = async () => {
        // connect todos collection
        const itemsCol = collection(db, "items");
        
        const itemSnapshot = await getDocs(itemsCol);
        // todo text and id 
        // document id is unique, so it can be used with deleting todo
        const items = itemSnapshot.docs.map(doc => {
          return  { 
            title: doc.data().title,
            id: doc.data().id,
            store: doc.data().store,
            price: doc.data().price,
            user: doc.data().user,
            email: doc.data().email,
            brand: doc.data().brand,
            checked: doc.data().checked
          };
        });
        // set states
        items.filter(item => {
            return item.user === uid
        });
        setItems(items);
        setLoading(false);
      }
      // start loading data
      
      fetchData();
  
      
    },[items, uid]); // called only once
  
    const handleSubmit = async (event: React.SyntheticEvent) => {
      // prevent normal submit event
      event.preventDefault();
      // add item to items, Math.random() is used to generate "unique" ID...
      let newItem:NewItem =  { 
        title: itemTitle, 
        brand: itemBrand,
        price: itemPrice, 
        store: itemStore, 
        email: email, 
        user: uid, 
        checked: false //for a new item, the checked value is always false
       };
      const docRef = await addDoc(collection(db, "items"), newItem);
      // get added doc id and set id to newItem
      const newId = docRef.id;
      const docRefGet = doc(db, "items", newId)
      const docSnap = await getDoc(docRefGet);
      const newData = docSnap.data();
      
      const dbItem:Item = {
        id: newId,
        title: newData?.title,
        brand: newData?.brand,
        price: newData?.brand,
        store: newData?.store,
        email: newData?.email,
        user: newData?.user,
        checked: newData?.user
      }
               
      
      //newItem.id = docRef.id;
      // update states in App
      setItems( [...items, dbItem]);
      // modify newItem text to ""
     
      clearFields();
     
    }

    const clearFields = () => {
      setItemTitle("")
      setStore("");
      setPrice(0);
      setBrand("");
    }
  
    const removeItem = (itemId: string  ) => {
      // filter/remove item with id
      deleteDoc(doc(db, "items", itemId));
      // delete from items state and update state
      let filteredArray = items.filter(collectionItem => collectionItem.id !== itemId);
      setItems(filteredArray); 
    }

    const checkItem = (itemId:string) =>{
     const checked:boolean = true;
     console.log(checked);
      //UPDATE DOCUMENT!
    }
  
  
    return (
      <div>
       <AddForm handleSubmit={handleSubmit} setItemTitle={setItemTitle} setBrand={setBrand} setStore={setStore} setPrice={setPrice} itemTitle={itemTitle} itemBrand={itemBrand} itemStore={itemStore} itemPrice={itemPrice} />
        <ul>
            
        { loading  && 
          <p>Loading...</p>
        }
        {items.map(item => (
          <li key={item.id}>
            <div> {item.title+" "}</div>
            <div> <span onClick={()=> checkItem(item.id)}>check</span> 
            <span onClick={() => removeItem(item.id)}> x </span>
            </div>
          </li>
        ))}
  
      </ul>    
      </div>
    )  
  }

export default ShoppingList;
