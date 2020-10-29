<template>
  <div class="vault-component col-4">
    <div class="card">
      <div class="card-body">
        <p>{{ vaultProp.isPrivate }}</p>
        <button class="btn btn-success" @click="openVault">Open Vault</button>
        <button class="btn btn-danger" @click="deleteVault">
          DELETE VAULT
        </button>
        <h4 class="card-title">{{ vaultProp.name }}</h4>
      </div>
    </div>
  </div>
</template>


<script>
import router from "../router/index.js";
export default {
  name: "vault-component",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    openVault() {
      router.push({ name: "Vault", params: { id: this.vaultProp.id } });
    },
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultProp);
    },
  },
  components: { router },
};
</script>


<style scoped>
.cursor {
  cursor: pointer;
}
</style>