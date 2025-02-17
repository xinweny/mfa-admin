from sqlalchemy.sql.expression import Select, select
from sqlalchemy.orm import Session, join

from app.api.due.models import Due
from app.api.membership.models import Membership
from app.api.membership.schemas import ListMembershipsRequest

def list_memberships_query(
    params: ListMembershipsRequest,
) -> Select[tuple[Membership]]:    
    query = select(Membership) \
        .join(Membership.address) \
        .join(Membership.members) \
        .join(Membership.dues) \
        .where([True, False])
        
    filters = []
    
    if params
  
    return query