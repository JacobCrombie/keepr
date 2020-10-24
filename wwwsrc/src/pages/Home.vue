<template>
  <div class="home-page container-fluid">
    <div class="row">
      <h1 class="text-center col">Welcome to Keepr</h1>
    </div>

    <div class="row">
      <form class="col" @submit.prevent="createKeep">
        <div class="form-group-inline col-6">
          <input
            type="text"
            class="form-control"
            placeholder="Name..."
            v-model="keepData.name"
          />
          <input
            type="text"
            class="form-control"
            placeholder="Description..."
            v-model="keepData.description"
          />
          <input
            type="text"
            class="form-control"
            placeholder="Image Url..."
            v-model="keepData.img"
          />
          <button class="btn btn-info" type="submit">Add Keep</button>
        </div>
      </form>
    </div>
    <div class="row justify-content-around">
      <keep-component v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import keepComponent from "../components/KeepComponent";
export default {
  name: "home-page",
  mounted() {
    this.$store.dispatch("getAllKeeps");
  },
  data() {
    return {
      keepData: {},
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
  },
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.keepData);
      this.keepData = {};
    },
  },
  components: { keepComponent },
};
</script>


<style scoped>
</style>

