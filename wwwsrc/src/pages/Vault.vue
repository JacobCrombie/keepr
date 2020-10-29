<template>
  <div class="vault-page">
    <h1>Keeps</h1>
    <div class="row justify-content-around">
      <keep-component v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import KeepComponent from "../components/KeepComponent";
export default {
  name: "vault-page",
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
    this.$store.dispatch("getVaultById", this.$route.params.id);
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
  components: { KeepComponent },
};
</script>


<style scoped>
</style>