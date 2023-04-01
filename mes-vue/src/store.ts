import {defineStore} from "pinia";
import {reactive, ref} from "vue";
export const useStore=defineStore("store",()=> {
    const newOrder=reactive<OrderType>({
        id:0,color:"红色",dosage:0,production:0,position:0,
    });
    const nextId=ref(1);
    return {newOrder,nextId};
})
export type OrderType={
    id:number,
    dosage:number,
    color:string,
    production:number,
    position:number,
};
