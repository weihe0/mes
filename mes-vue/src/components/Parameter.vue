<template>
  <form>
      <div class="number">
          <label>药丸数量</label>
          <input type="number" v-model="store.newOrder.dosage" />
      </div>
      <div class="select">
          <label>颜色</label>
          <button @click="setColor('red')"
          :style="{background:buttonColors[0]}"
          >红色</button>
          <button @click="setColor('yellow')"
                  :style="{background:buttonColors[1]}"
          >黄色</button>
          <button @click="setColor('metal')"
                  :style="{background:buttonColors[2]}"
      >金属色</button>
      </div>
      <div class="number">
          <label>产量</label>
          <input type="number" v-model="store.newOrder.production" />
      </div>
      <div class="select">
          <label>位置</label>
          <button v-for="i of [0,1,2,3]"
                  :style="{background:positionColors[i]}"
                  @click="setPosition(i)"
          >{{i+1}}</button>
      </div>

  </form>
</template>
<style scoped>
form{
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-template-rows: 1fr 1fr;
    border: solid black 1px;
}
form div{
    margin: 1em;
}
.number{
    display: grid;
    grid-template-rows: 1fr 2fr;
}
.select{
    display: grid;
    grid-template-areas:
      "l l l"
      "b b b";
}
</style>
<script setup lang="ts">
import {useStore} from "../store";
import {ref} from "vue";
const store=useStore();
store.newOrder.id=Math.round(Math.random());
store.newOrder.color="金属色";

const buttonColors=ref(["","",""]);
const positionColors=ref(["","","",""]);
function setColor(color:string){
    switch (color){
        case "red":
            for(let i=0;i<3;i++){
                buttonColors.value[i]="";
            }
            buttonColors.value[0]="red";
            store.newOrder.color="红色";
            break;
        case "yellow":
            for(let i=0;i<3;i++){
                buttonColors.value[i]="";
            }
            buttonColors.value[1]="yellow";
            store.newOrder.color="黄色";
            break;
        case "metal":
            for(let i=0;i<3;i++){
                buttonColors.value[i]="";
            }
            buttonColors.value[2]="rgb(186,110,64)";
            store.newOrder.color="金属色";
            break;
    }
}
function setPosition(position:number){
    for(let i=0;i<positionColors.value.length;i++){
        positionColors.value[i] = i === position ? "darkgray" : "";
    }
    store.newOrder.position = position;
}
</script>
