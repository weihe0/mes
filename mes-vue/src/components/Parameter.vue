<template>
  <Layout>
    <form id="parameter" @click.prevent="">
      <div id="color">
        <label>请选择药品颜色</label>
        <input type="color" />
      </div>
      <div id="pill">
        <label>请选择药品数量</label>
        <input type="number" />
      </div>
      <div id="position">
        <button>1</button>
        <button>2</button>
        <button>3</button>
        <button>4</button>
      </div>
      <div id="production">
        <label>请选择产量</label>
        <input type="number" />
      </div>
    </form>
  </Layout>
</template>
<style scoped>
#parameter{
  flex: auto;
  display: grid;
  grid-template-rows: 1fr 1fr;
  grid-template-columns: 1fr 1fr;
}
#color{
  display: flex;
  justify-content: center;
  align-items: center;
}
#pill{
  display: flex;
  justify-content: center;
  align-items: center;
}
#position{
  display: grid;
  grid-template-rows: 1fr 1fr;
  grid-template-columns: 1fr 1fr;
  padding: 1em;
}
#position button{
  width: 100%;
  height: 100%;
  border: solid black 2px;
  font-size: 4em;
}

#production{
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
<script setup lang="ts">
import Layout from "./Layout.vue";
</script>


