export const formatMemberNames = (members: {
  firstName: string;
  lastName: string;
}[]) => {
  return members.map(m => `${m.firstName} ${m.lastName}`).join(', ');
};