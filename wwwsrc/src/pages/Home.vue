<template>
  <div class="home-page container-fluid">
    <div class="row">
      <h1 class="text-center col">Welcome to Keepr</h1>
    </div>
    <div class="row">
      <div class="col card-columns">
        <keep-component v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
      </div>
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
    return {};
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
  },
  methods: {},
  components: { keepComponent },
};
</script>


<style scoped>
</style>

