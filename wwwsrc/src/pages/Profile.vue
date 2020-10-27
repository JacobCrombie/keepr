<template>
  <div class="profile-page container-fluid">
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

    <h1>Vaults</h1>
    <div class="row justify-content-around">
      <vault-component
        v-for="vault in vaults"
        :key="vault.id"
        :vaultProp="vault"
      />
    </div>

    <h1>Keeps</h1>
    <div class="row justify-content-around">
      <keep-component v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import KeepComponent from "../components/KeepComponent";
import VaultComponent from "../components/VaultComponent";
export default {
  name: "profile-page",
  mounted() {
    this.$store.dispatch("getKeepsByProfile", this.$route.params.id);
    this.$store.dispatch("getVaultsByProfile", this.$route.params.id);
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
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    createKeep() {
      let keepData = {
        creatorId: this.$route.params.id,
        description: this.keepData.description,
        name: this.keepData.name,
        img: this.keepData.img,
      };
      this.$store.dispatch("createKeep", keepData);
      this.keepData = {};
    },
  },
  components: { KeepComponent, VaultComponent },
};
</script>


<style scoped>
</style>