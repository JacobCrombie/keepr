<template>
  <div class="vault-component col-4">
    <div class="card">
      <div class="card-body">
        <p>{{vaultProp.isPrivate}}</p>
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