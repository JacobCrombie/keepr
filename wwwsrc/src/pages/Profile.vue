<template>
  <div class="profile-page container-fluid">
    <h1>Keeps</h1>
    <div class="row justify-content-around">
      <keep-component v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
    <div class="row justify-content-around">
      <vault-component v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
    </div>
  </div>
</template>


<script>
import KeepComponent from "../components/KeepComponent";
import VaultComponent from "../components/VaultComponent"
export default {
  name: "profile-page",
  mounted() {
    this.$store.dispatch("getKeepsByProfile", this.$route.params.id);
  },
  data() {
    return {};
  },
  computed: {
    keeps() {
      return this.$store.state.queryUserKeeps;
    },
  },
  methods: {},
  components: { KeepComponent, VaultComponent },
};
</script>


<style scoped>
</style>