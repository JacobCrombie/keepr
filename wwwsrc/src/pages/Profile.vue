<template>
  <div class="profile-page container-fluid">
    <div class="row">
      <div class="card">
        <img
          class="card-img-right"
          v-if="this.$route.params.id == searchedProfile.id"
          :src="searchedProfile.picture"
        />
        <img class="card-img-right" v-else :src="profile.picture" />
        <div class="card-body">
          <h4
            class="card-title"
            v-if="this.$route.params.id == searchedProfile.id"
          >
            {{ searchedProfile.name }}
          </h4>
          <h4 class="card-title" v-else>{{ profile.name }}</h4>
          <p
            class="card-text"
            v-if="this.$route.params.id == searchedProfile.id"
          >
            {{ searchedProfile.email }}
          </p>
          <p class="card-text" v-else>{{ profile.email }}</p>
        </div>
        <p>Keeps:{{ keeps.length }}</p>
        <p>Vaults:{{ vaults.length }}</p>
      </div>
    </div>
    <div class="row" v-if="profile.id == this.$route.params.id">
      <h4>Add A Keep</h4>
      <form class="col" @submit.prevent="createKeep">
        <div class="form-group form-inline">
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
          <button class="btn btn-info" type="submit" data-dismiss="modal">
            Add Keep
          </button>
        </div>
      </form>
    </div>

    <div class="row" v-if="profile.id == this.$route.params.id">
      <h4>Add A Vault</h4>
      <form @submit.prevent="createVault">
        <div class="form-group form-inline">
          <input
            type="text"
            class="form-control"
            placeholder="Name..."
            v-model="vaultData.name"
          />
          <input
            type="text"
            class="form-control"
            placeholder="Description"
            v-model="vaultData.description"
          />
          <label for="isPrivate">Private</label>
          <input type="checkbox" v-model="vaultData.isPrivate" />
          <button type="submit" class="btn btn-primary">Add Vault</button>
        </div>
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
  props: ["keepProp"],
  mounted() {
    this.$store.dispatch("getKeepsByProfile", this.$route.params.id);
    this.$store.dispatch("getVaultsByProfile", this.$route.params.id);
    this.$store.dispatch("getProfileById", this.$route.params.id);
    console.log(this.$route.name);
  },
  data() {
    return {
      keepData: {},
      vaultData: {},
    };
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      if (this.profile.id == this.$route.params.id) {
        return this.$store.state.myVaults;
      }
      let publicVaults = this.$store.state.vaults.filter(
        (v) => v.isPrivate != true
      );
      return publicVaults;
    },
    profile() {
      return this.$store.state.profile;
    },
    searchedProfile() {
      return this.$store.state.searchedProfile;
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
    createVault() {
      let vaultData = {
        creatorId: this.$route.params.id,
        description: this.vaultData.description,
        name: this.vaultData.description,
        isPrivate: this.vaultData.isPrivate,
      };
      this.$store.dispatch("createVault", vaultData);
      this.vaultData = {};
    },
  },
  components: { KeepComponent, VaultComponent },
};
</script>


<style scoped>
</style>