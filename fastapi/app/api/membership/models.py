from datetime import datetime, date
from typing import Optional
from uuid import UUID

from sqlalchemy import DateTime, ForeignKey
from sqlalchemy.sql import func
from sqlalchemy.orm import Mapped, mapped_column, relationship

from app.database import Base
from app.api.member.models import Member
from app.api.address.models import Address
from app.api.due.models import Due
from app.api.membership.constants import MembershipType

class Membership(Base):
    __tablename__ = 'memberships'
  
    id: Mapped[UUID] = mapped_column(primary_key=True)
    
    membership_type: Mapped[MembershipType]
    start_date: Mapped[date]
    is_active: Mapped[bool]
    
    # pylint: disable=not-callable
    created_at: Mapped[datetime] = mapped_column(DateTime(timezone=True), server_default=func.now())
    updated_at: Mapped[Optional[datetime]] = mapped_column(DateTime(timezone=True), onupdate=datetime.now)
    
    address_id: Mapped[Optional[UUID]] = mapped_column(ForeignKey('addresses.id'))
    address: Mapped[Optional[Address]] = relationship(Address, back_populates='child')
    members: Mapped[Member] = relationship(Member, back_populates='parent')
    dues: Mapped[Due] = relationship(Due, back_populates='parent')