import React from "react";

interface props {
  handleSubmit: (event: React.SyntheticEvent) => void ;
  setItemTitle: React.Dispatch<React.SetStateAction<string>>;
  setBrand: React.Dispatch<React.SetStateAction<string>>; 
  setStore: React.Dispatch<React.SetStateAction<string>>;
  setPrice: React.Dispatch<React.SetStateAction<number>>;
  itemTitle: string;
  itemBrand: string;
  itemStore: string; 
  itemPrice: number;
}
const AddForm:React.FC<props> = ({ handleSubmit,
  setItemTitle,
  setBrand, 
  setStore,
  setPrice,
  itemTitle,
  itemBrand,
  itemStore, 
  itemPrice}) => {
  return (
    <div> <form onSubmit={handleSubmit}>
    <input type="text" value={itemTitle} onChange={event => setItemTitle(event.target.value)} placeholder="Write a new item title here" />
    <input type="text" value={itemBrand} onChange={event => setBrand(event.target.value)} placeholder="Write the brand of your new item here" />
    <input type="text" value={itemStore} onChange={event => setStore(event.target.value)} placeholder="Write the store of your new item here" />
    <input type="text" value={itemPrice} onChange={event => setPrice(parseFloat(event.target.value))} placeholder="Write the price of your new item here" />
    <input type="submit" value="Add"/>
  </form></div>
  )
}

export default AddForm
