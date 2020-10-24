<template>
  <div class="home-page container-fluid">
    <h1>Welcome</h1>
    <div class="row justify-content-between">
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

