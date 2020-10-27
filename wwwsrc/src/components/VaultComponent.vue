<template>
  <div class="vault-component col-4">
    <div class="card">
      <img
        class="card-img-top"
        :src="vaultProp.img || 'http://placehold.it/200x200'"
      />
      <div class="card-body">
        <i class="fa fa-plus text-success cursor" @click="openVault"></i>
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
  },
  components: { router },
};
</script>


<style scoped>
.cursor {
  cursor: pointer;
}
</style>