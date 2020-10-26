<template>
  <div class="home-page container-fluid">
    <div class="row">
      <h1 class="text-center col">Welcome to Keepr</h1>
    </div>

    <div class="row">
      <form class="col" @submit.prevent="createKeep">
        <div class="form-group-inline">
          <h4 class="text-center">Add A Keep</h4>
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
        </div>
        <button class="btn btn-info" type="submit" data-dismiss="modal">
          Add Keep
        </button>
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
    toggleModal() {},
  },
  components: { keepComponent },
};
</script>


<style scoped>
</style>

